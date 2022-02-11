import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: any = {};
  registerForm: FormGroup;
  maxDate: Date;

  constructor(
    private accountService: AccountService,
    private toastr: ToastrService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.inititalizeForm();
    this.maxDate = new Date();
    this.maxDate.setFullYear(this.maxDate.getFullYear())
  }

  inititalizeForm() {
    this.registerForm = this.fb.group({
      gender: ['female'],
      username: ['', Validators.required],
      knownAs: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      city: ['', Validators.required],
      country: ['', Validators.required],
      password: [
        '',
        [Validators.required, Validators.minLength(4), Validators.maxLength(8)],
      ],
      confirmPassword: [
        '',
        [Validators.required, this.matchValues('password')],
      ],
    });
    this.registerForm.controls.password.valueChanges.subscribe(() => {
      this.registerForm.controls.confirmPassword.updateValueAndValidity();
    });
  }

  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control?.value === control?.parent?.controls[matchTo].value
        ? null
        : { isMatching: true };
    };
  }

  register() {
    // this.accountService.register(this.model).subscribe(response => {
    console.log(this.registerForm.value);
    //   this.cancel();
    // }, error => {
    //   console.error(error);
    //   this.toastr.error(error.error);
    // });
  }

  cancel() {
    // console.log('cancelled');
    this.cancelRegister.emit(false);
  }
}
