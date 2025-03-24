import { Routes } from '@angular/router';
import { LogComponent} from './page/log/log.component'
import { ProductoListComponent } from './components/producto-list/producto-list.component';
import { ProductoFormComponent } from './components/producto-form/producto-form.component';

export const routes: Routes = [
    { path:"", component: LogComponent},
    { path:"listaProducto", component: ProductoListComponent},
    { path:"agregarProducto", component: ProductoFormComponent}
];
