import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material';
import { Observable, Subscription } from 'rxjs';
import { SpinnerDialogContentComponent } from './spinner-dialog-content.component';
//import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';

@Component({
  selector: 'spinner-dialog',
  templateUrl: './spinner-dialog.component.html',
  styleUrls: ['./spinner-dialog.component.scss']
})
export class SpinnerDialogComponent implements OnInit {

  //displayed : boolean; 
  constructor(private dialog: MatDialog) {
    //this.displayed = false; 
  }

  ngOnInit() {
  }
 
  displaySpinner(observable: Observable<any>) {
    const dialogRef: MatDialogRef<SpinnerDialogContentComponent> 
      = this.dialog.open(SpinnerDialogContentComponent, {
        panelClass: 'transparent',
        width:'400px',
        disableClose: true
      });
    //this.displayed = true;  
    let subscription = observable.subscribe(
      (response: any) => {
        subscription.unsubscribe();
        //handle response
        console.log(response);
        //this.displayed = false;
        dialogRef.close();
      },
      (error) => {
        subscription.unsubscribe();
        //this.displayed = false;
        //handle error
        dialogRef.close();
      }
    );
  }
}
