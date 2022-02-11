import { Component, Input, OnInit, Self } from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { reduce } from 'rxjs/operators';

@Component({
  selector: 'app-date-input',
  templateUrl: './date-input.component.html',
  styleUrls: ['./date-input.component.css']
})
export class DateInputComponent implements ControlValueAccessor {
@Input() lable: string;
@Input() maxDate: Date;
bsConfit: Partial<BsDatepickerConfig>;

  constructor(@Self() public ngControl: NgControl) {
    this.ngControl.valueAccessor = this;
    this.bsConfit = {
      containerClass: reduce,
      
    }
   }

  writeValue(obj: any): void {
      }

  registerOnChange(fn: any): void {
  }

  registerOnTouched(fn: any): void {
  }



}
