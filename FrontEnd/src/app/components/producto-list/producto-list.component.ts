import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { ProductoService } from '../../services/producto.service'; 
import * as boostrap from 'boostrap';

@Component({
  selector: 'app-producto-list',
  //standalone:true,
  //imports: [CommonModule],
  templateUrl: './producto-list.component.html',
  styleUrl: './producto-list.component.css'
})
export class ProductoListComponent implements OnInit{
  productos: any[] = [];
  modalInstance: any

  constructor(private productoService: ProductoService,
              private router:Router
  ) {}

  ngOnInit(): void {
    this.obtenerProductos();
    /*this.productoService.getProductos().subscribe(productos => {
      console.log(productos);
    });*/
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

  abrirModal(): void {
    const modalElement = document.getElementById("modalProduct");
    if(modalElement){
      this.modalInstance = new boostrap.Modal(modalElement);
      this.modalInstance.show();
    }
    //this.router.navigate(["/agregarProducto"])
  }

}
