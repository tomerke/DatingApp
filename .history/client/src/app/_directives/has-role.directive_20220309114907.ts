import { Directive, TemplateRef, ViewContainerRef } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Directive({
  selector: '[appHasRole]'
})
export class HasRoleDirective {

  constructor(private viewContainerRef: ViewContainerRef, private templateRef: TemplateRef<any>,
              private accoutService: AccountService) { }

}
