import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BoxesComponent } from './boxes/boxes.component';
import { BoxviewComponent } from './boxview/boxview.component';
import { OrdersComponent } from './orders/orders.component';

const routes: Routes = [
  { path: '', component: BoxesComponent },
  { path: 'view/:id', component: BoxviewComponent },
  { path: 'orders', component: OrdersComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomePageRoutingModule {}
