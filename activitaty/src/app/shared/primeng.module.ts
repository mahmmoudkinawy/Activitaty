import { NgModule } from '@angular/core';

import { CardModule } from 'primeng/card';
import { ButtonModule } from 'primeng/button';
import { MenubarModule } from 'primeng/menubar';
import { FieldsetModule } from 'primeng/fieldset';
import { TagModule } from 'primeng/tag';

const primeNgComponents = [
  CardModule,
  ButtonModule,
  MenubarModule,
  FieldsetModule,
  TagModule,
];

@NgModule({
  exports: [primeNgComponents],
})
export class PrimengModule {}
