import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomersComponent } from './customers/customers.component';
import { ProductsComponent } from './products/products.component';
import { ECommerceComponent } from './e-commerce.component';
import { ECommerceRoutingModule } from './e-commerce-routing.module';

@NgModule({
  declarations: [CustomersComponent, ProductsComponent, ECommerceComponent],
  imports: [CommonModule, ECommerceRoutingModule],
})
export class ECommerceModule {}
