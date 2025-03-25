import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-log',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './log.component.html',
  styleUrl: './log.component.css'
})
export class LogComponent {
  email: string="";
  password: string="";

  constructor(private router:Router){}
  aceptar(){
    console.log("email", this.email, "password", this.password)
    if (!this.email.includes("@")) {
      alert("Por favor, ingrese un email válido");
      return;
    }
  
    if (this.password.length < 5) {
      alert("La contraseña debe tener al menos 5 caracteres");
      return;
    }
  
    //alert("Login exitoso");
    this.router.navigate(["/listaProducto"]);
  }
}
