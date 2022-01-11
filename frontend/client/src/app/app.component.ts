import { Component } from '@angular/core';
//electron-packager client --platform=win32 --no-prune --ignore=/node_modules --ignore=/e2e --ignore=/src
/* "name": "angular-cli-electron",
"productName": "Angular CLI + Electron",
"version": "1.0.0",
"description": "Angular CLI + Electron",
"main": "electron.prod.js",
"license": "MIT"
*/
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Magni';
}
