import { Component, OnInit } from '@angular/core';
import { EmpleadoService } from '../../services/empleado.service';
import { Empleado } from '../../models/empleado.model';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-empleado-list',
  templateUrl: './empleado-list.component.html',
  styleUrls: ['./empleado-list.component.css']
})
export class EmpleadoListComponent implements OnInit {
  empleados: Empleado[] = [];

  constructor(
    private empleadoService: EmpleadoService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.cargarEmpleados();
  }

  cargarEmpleados(): void {
    this.empleadoService.getEmpleados().subscribe((data) => {
      this.empleados = data;
    });
  }

  editarEmpleado(empleadoId: string): void {
    // Redirigir al usuario al formulario de edición con el ID del empleado
    this.router.navigate(['/editar-empleado', empleadoId]);
  }

  eliminarEmpleado(id: string): void {
    // Llamar al servicio para eliminar el empleado y luego recargar la lista
    this.empleadoService.deleteEmpleado(id).subscribe(() => {
      // Recargar la lista de empleados
      this.cargarEmpleados();
    });
  }

  displayedColumns: string[] = ['nombre', 'apellido', 'cargo', 'email', 'acciones'];

}
