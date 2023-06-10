import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListComponent } from './customer/list/list.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  {path: 'home', component: HomeComponent},
  {path: 'list', component: ListComponent, canActivate: [AuthGuard]},
    // {path: 'customer/edit', component: CustomerEditComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
