// src/app/models/empleado.model.ts

export class Empleado {
  id?: string; // El signo de interrogación indica que la propiedad es opcional (útil para creaciones)
  nombre: string;
  apellido: string;
  email: string;
  cargo: string;
  departamentoId: string;
  puestoId: string;

  constructor(
    nombre: string,
    apellido: string,
    email: string,
    cargo: string,
    departamentoId: string,
    puestoId: string,
    id?: string
  ) {
    this.nombre = nombre;
    this.apellido = apellido;
    this.email = email;
    this.cargo = cargo;
    this.departamentoId = departamentoId;
    this.puestoId = puestoId;
    if (id) {
      this.id = id;
    }
  }
}

