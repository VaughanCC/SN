import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.scss']
})
export class ModalComponent implements OnInit {
  display: string = 'none';
  constructor() { }

  ngOnInit() {
  }

  openModal() {
    this.display = 'block';
  }

  onCloseHandled(){
    this.display='none'; 
  }

}
