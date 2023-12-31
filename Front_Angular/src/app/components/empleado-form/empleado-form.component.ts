// src/app/components/empleado-form/empleado-form.component.ts
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmpleadoService } from '../../services/empleado.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-empleado-form',
  templateUrl: './empleado-form.component.html',
  styleUrls: ['./empleado-form.component.css']
})
export class EmpleadoFormComponent {
  empleadoForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private empleadoService: EmpleadoService,
    private router: Router
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

  onSubmit(): void {
    if (this.empleadoForm.valid) {
      this.empleadoService.createEmpleado(this.empleadoForm.value).subscribe(() => {
        this.router.navigate(['/empleados']); // Redirige al usuario a la lista de empleados
      });
    }
  }
}
