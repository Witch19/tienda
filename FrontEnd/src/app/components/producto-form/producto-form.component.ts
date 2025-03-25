import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProductoService } from '../../services/producto.service';
import { Product } from '../../services/producto.model'; 

@Component({
  selector: 'app-producto-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './producto-form.component.html',
  styleUrl: './producto-form.component.css'
})
export class ProductoFormComponent {
  producto: Product = {  
    id: 0, 
    name: '',
    descripcion: '',
    price: 0, 
    stock: 0
  };

  constructor(private productoService: ProductoService){}

  saveProduct(): void {
    this.productoService.crearProducto(this.producto).subscribe(() => {
      alert("Producto agregado correctamente");
      this.producto = { id: 0, name: "", descripcion: "", price: 0, stock: 0 };
    });
  }

}
