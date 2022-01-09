import { Component } from '@angular/core';
//electron-packager client --platform=win32 --no-prune --ignore=/node_modules --ignore=/e2e --ignore=/src

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Magni';
}
