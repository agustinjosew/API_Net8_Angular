// src/app/app-routing.module.ts
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmpleadoListComponent } from './components/empleado-list/empleado-list.component';
import { EmpleadoFormComponent } from './components/empleado-form/empleado-form.component';

const routes: Routes = [
  { path: 'empleados', component: EmpleadoListComponent },
  { path: 'crear-empleado', component: EmpleadoFormComponent },
  { path: 'editar-empleado/:id', component: EmpleadoFormComponent}
  // Añadir más rutas según sea necesario con la evolucion 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
