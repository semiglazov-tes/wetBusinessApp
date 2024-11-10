import { Routes } from '@angular/router';
import {LayoutComponent} from "./common-ui/layout/layout.component";
import {AuthComponent} from "./pages/auth/auth/auth.component";

export const routes: Routes = [
  {path:'',component:AuthComponent},
  {path:'main',component:LayoutComponent}
];
