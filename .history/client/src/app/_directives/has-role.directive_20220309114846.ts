import { Directive, TemplateRef, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[appHasRole]'
})
export class HasRoleDirective {

  constructor(private viewContainerRef: ViewContainerRef, private templateRef: TemplateRef<any>) { }

}
