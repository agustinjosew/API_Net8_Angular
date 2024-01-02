// src/app/components/empleado-form/empleado-form.component.ts
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EmpleadoService } from '../../services/empleado.service';
import { Empleado } from '../../models/empleado.model';

@Component({
  selector: 'app-empleado-form',
  templateUrl: './empleado-form.component.html',
  styleUrls: ['./empleado-form.component.css']
})
export class EmpleadoFormComponent implements OnInit {
  empleadoForm: FormGroup;
  esEdicion: boolean = false;
  empleadoId: string ='';

  constructor(
    private formBuilder: FormBuilder,
    private empleadoService: EmpleadoService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.empleadoForm = this.formBuilder.group({
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      cargo: ['', Validators.required],
      departamentoId: ['', Validators.required],
      puestoId: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    // Obtener el ID del empleado de la ruta si está presente
    this.empleadoId = this.route.snapshot.params['id'];
    if (this.empleadoId) {
      this.esEdicion = true;
      this.empleadoService.getEmpleadoById(this.empleadoId).subscribe((empleado) => {
        // Aquí puedes usar el método patchValue o setValue para actualizar los valores del formulario.
        this.empleadoForm.patchValue(empleado);
      });
    }
  }

  onSubmit(): void {
    if (this.empleadoForm.valid) {
      if (this.esEdicion) {
        // Actualizar empleado
        this.empleadoService.updateEmpleado(this.empleadoId, this.empleadoForm.value).subscribe(() => {
          this.router.navigate(['/empleados']); // Redirige al usuario a la lista de empleados
        });
      } else {
        // Crear nuevo empleado
        this.empleadoService.createEmpleado(this.empleadoForm.value).subscribe(() => {
          this.router.navigate(['/empleados']); // Redirige al usuario a la lista de empleados
        });
      }
    }
  }
}
