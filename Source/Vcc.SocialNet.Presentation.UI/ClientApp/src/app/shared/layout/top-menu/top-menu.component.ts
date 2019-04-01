import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'top-menu',
  templateUrl: './top-menu.component.html',
  styleUrls: ['./top-menu.component.scss']
})
export class TopMenuComponent implements OnInit {
  isCollapsed: boolean = true;
  latestMessageId: number = 1;
  constructor() { }

  ngOnInit() {
  }

  
}
