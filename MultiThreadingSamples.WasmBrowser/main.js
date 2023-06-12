// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

import { dotnet } from './dotnet.js'

const { setModuleImports, getAssemblyExports, getConfig } = await dotnet
    .withDiagnosticTracing(false)
    .withApplicationArgumentsFromQuery()
    .create();

setModuleImports('main.js', {
    view: {
        setHtml: (id, html) => {
            var e = globalThis.document.getElementById(id);

            if (e)
                e.innerHTML = html;
        }
    },
    window: {
        alert: msg => globalThis.window.alert(msg),
        location: {
            href: () => globalThis.window.location.href
        },
        print: s => globalThis.document.getElementById('out').innerHTML += s,
        setDisable: (id, disable) => {
            var e = globalThis.document.getElementById(id);

            if (e)
                e.disable = disable;
        }
    }
});

const config = getConfig();
const exports = await getAssemblyExports(config.mainAssemblyName);
//const text = exports.MyClass.Greeting();
//console.log(text);

globalThis.Main = exports.Main;
globalThis.ComputePi = exports.ComputePi;
globalThis.OnClickComputePi = exports.ComputePi.Main;
globalThis.SerialPi = exports.ComputePi.SerialPi;
globalThis.ThreadPi = exports.ComputePi.ThreadPi;

//document.getElementById('out').innerHTML = text;
await dotnet.run();

exports.ComputePi.OnReady();