import { Component, OnInit } from '@angular/core';
import { EmpleadoService } from '../../services/empleado.service';
import { Empleado } from '../../models/empleado.model';

@Component({
  selector: 'app-empleado-list',
  templateUrl: './empleado-list.component.html',
  styleUrls: ['./empleado-list.component.css']
})
export class EmpleadoListComponent implements OnInit {
  empleados: Empleado[] = [];

  constructor(private empleadoService: EmpleadoService) { }

  ngOnInit(): void {
    this.empleadoService.getEmpleados().subscribe((data) => {
      this.empleados = data;
    });
  }

  editarEmpleado(empleado: Empleado): void {
    // implementar la lógica para editar un empleado
  }

  eliminarEmpleado(id: string): void {
    // implementar la lógica para eliminar un empleado
  }

  displayedColumns: string[] = ['nombre', 'apellido', 'cargo', 'acciones'];

}
