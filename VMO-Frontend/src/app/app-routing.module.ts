import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CategoryModule } from './pages/category/category.module';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/welcome' },
  { path: 'welcome', loadChildren: () => import('./pages/welcome/welcome.module').then(m => m.WelcomeModule) },
  { path: 'category', loadChildren: () => import('./pages/category/category.module').then(m => m.CategoryModule) },
  { path: 'management', loadChildren: () => import('./pages/management/management.module').then(m => m.ManagementModule) },
  { path: 'setting', loadChildren: () => import('./pages/setting/setting.module').then(m => m.SettingModule) }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
