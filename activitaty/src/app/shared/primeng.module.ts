import { NgModule } from '@angular/core';

import { CardModule } from 'primeng/card';

const primeNgComponents = [CardModule];

@NgModule({
  exports: [primeNgComponents],
})
export class PrimengModule {}
