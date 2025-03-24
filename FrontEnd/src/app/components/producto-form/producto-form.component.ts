import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProductoService } from '../../services/producto.service';

@Component({
  selector: 'app-producto-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './producto-form.component.html',
  styleUrl: './producto-form.component.css'
})
export class ProductoFormComponent {
  producto={
    nombre: "",
    precio: 0
  }

  constructor(private productoService: ProductoService){}

  saveProduct(): void{
    const newProduct = {nombre:this.producto.nombre,
                        precio:this.producto.precio
                       };
    this.productoService.crearProducto(newProduct).subscribe(()=>{
      alert("Producro agregado correctamente");
      this.producto ={nombre: "", precio: 0};
    })
  }

}
