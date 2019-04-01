import { Component, OnInit } from '@angular/core';
import { APP_VERSION } from 'src/environments/version';

/**
 * Represents the footer section that shows up on all pages
 */
@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {

  version: string = APP_VERSION.version;
  constructor() { }

  ngOnInit() {
  }
}
