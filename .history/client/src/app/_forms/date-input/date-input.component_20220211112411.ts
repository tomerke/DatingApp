import { Component, Input, OnInit, Self } from '@angular/core';
import { ControlValueAccessor } from '@angular/forms';

@Component({
  selector: 'app-date-input',
  templateUrl: './date-input.component.html',
  styleUrls: ['./date-input.component.css']
})
export class DateInputComponent implements ControlValueAccessor {
@Input() lable: string;
@Input() maxDate: Date;

  constructor(@Self() public ngControl: NgCon) { }

  writeValue(obj: any): void {
      }

  registerOnChange(fn: any): void {
  }

  registerOnTouched(fn: any): void {
  }



}
