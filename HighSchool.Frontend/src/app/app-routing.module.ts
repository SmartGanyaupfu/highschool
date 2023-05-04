import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestComponent } from './test/test.component';
import { DashboardComponent } from './pages/admin/dashboard/dashboard.component';
import { FeeCategoryListComponent } from './pages/admin/setup/fee-category-list/fee-category-list.component';

const routes: Routes = [

  { path: 'home', redirectTo: '', pathMatch: 'full' },

  { path: 'ss-admin/fee-categories', component: FeeCategoryListComponent},
  { path: '', component: DashboardComponent},
  { path: 'ss-admin', component: DashboardComponent},

  {
    path: '**',
    redirectTo: ''
  }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
