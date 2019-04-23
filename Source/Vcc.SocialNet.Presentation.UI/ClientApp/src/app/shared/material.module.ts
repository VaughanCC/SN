import { NgModule } from '@angular/core';
import {
  MatButtonModule, MatCheckboxModule, MatIconModule, 
  MatSidenavModule, MatToolbarModule, MatListModule, 
  MatCardModule, MatProgressSpinnerModule, MatDialogModule,
  MatFormFieldModule, MatInputModule
} from '@angular/material';

/**
 * Module that imports commonly used material modules as a group 
 * to avoid repeatedly importing individual material modules
 */
@NgModule({
  declarations: [],
  imports: [
    MatButtonModule, MatCheckboxModule, MatIconModule, MatSidenavModule, 
    MatToolbarModule, MatListModule, MatCardModule, MatProgressSpinnerModule,
    MatDialogModule, MatFormFieldModule, MatInputModule
  ],
  exports: [
    MatButtonModule, MatCheckboxModule, MatIconModule, MatSidenavModule, 
    MatToolbarModule, MatListModule, MatCardModule, MatProgressSpinnerModule,
    MatDialogModule, MatFormFieldModule, MatInputModule
  ]
})
export class MaterialModule { 

}
