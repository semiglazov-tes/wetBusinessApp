import { Component, Inject, inject } from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogActions, MatDialogContent, MatDialogClose, MatDialogRef, MatDialogTitle } from '@angular/material/dialog';
import {MatButtonModule} from "@angular/material/button";
import {NgStyle} from "@angular/common";

@Component({
  selector: 'app-error-window',
  standalone: true,
  imports: [
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
    MatDialogTitle,
    MatButtonModule,
    NgStyle
  ],
  templateUrl: './error-window.component.html',
  styleUrl: './error-window.component.scss'
})
export class ErrorWindowComponent {
  readonly dialogRef = inject(MatDialogRef<ErrorWindowComponent>);
  constructor(@Inject(MAT_DIALOG_DATA) public data: { message: string }) {}
}
