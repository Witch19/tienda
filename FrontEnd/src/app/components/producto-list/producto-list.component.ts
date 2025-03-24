import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductoService } from '../../services/producto.service'; 

@Component({
  selector: 'app-producto-list',
  //standalone:true,
  //imports: [CommonModule],
  templateUrl: './producto-list.component.html',
  styleUrl: './producto-list.component.css'
})
export class ProductoListComponent implements OnInit{
  //productos: any[] = [];

  constructor(private productoService: ProductoService) {}

  ngOnInit(): void {
    this.productoService.getProductos().subscribe(productos => {
      console.log(productos);
    });
  }

  obtenerProductos(): void {
    this.productoService.getProductos().subscribe(productos => {
      console.log(productos);
    });
  }

  eliminarProducto(id: number): void{
    if(confirm("seguro quieres eliminar?")){
      this.productoService.eliminarProducto(id).subscribe(()=>{
        this.obtenerProductos();
      });
    }
  }

}
