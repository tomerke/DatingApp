import { Directive, TemplateRef, ViewContainerRef } from '@angular/core';
import { take } from 'rxjs/operators';
import { AccountService } from '../_services/account.service';

@Directive({
  selector: '[appHasRole]'
})
export class HasRoleDirective {

  constructor(private viewContainerRef: ViewContainerRef, private templateRef: TemplateRef<any>,
              private accoutService: AccountService) {
                this.accoutService.currentUser$.pipe(take(1)).subscribe
               }

}
