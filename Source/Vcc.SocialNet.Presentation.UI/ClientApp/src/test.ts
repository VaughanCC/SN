// This file is required by karma.conf.js and loads recursively all the .spec and framework files

import 'zone.js/dist/zone-testing';
import { getTestBed } from '@angular/core/testing';
import {
  BrowserDynamicTestingModule,
  platformBrowserDynamicTesting
} from '@angular/platform-browser-dynamic/testing';

declare const require: any;

// First, initialize the Angular testing environment.
getTestBed().initTestEnvironment(
  BrowserDynamicTestingModule,
  platformBrowserDynamicTesting()
);

// Then we find all the tests.
//const context = require.context('./', true, /\.spec\.ts$/);

// if needed, we can limit angular test to run on a specific component only
//const context = require.context('./', true, /auth-layout.component\.spec\.ts$/);
const context = require.context('./', true, /(auth-layout.component|login.component|login.component.routing)\.spec\.ts$/);
// And load the modules.
//context.keys().map(context);
// if we want to exclude intergration.spec
context
  .keys()
  .filter(function(element, index) {
    // The regex in require.context didn't work for filtering integration testing off
    return !element.endsWith('.integration.spec.ts');
  })
  .map(context);
  