import { Directive, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[appHasRole]'
})
export class HasRoleDirective {

  constructor(private viewContainerRef: ViewContainerRef) { }

}
