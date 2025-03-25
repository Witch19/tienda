import { Component, OnInit, Inject, PLATFORM_ID } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { ProductoService } from '../../services/producto.service';
import { ProductoFormComponent } from '../producto-form/producto-form.component';
import { isPlatformBrowser } from '@angular/common';
import { Product } from '../../services/producto.model';

@Component({
  selector: 'app-producto-list',
  templateUrl: './producto-list.component.html',
  styleUrls: ['./producto-list.component.css'],
  imports: [CommonModule, ProductoFormComponent]
})
export class ProductoListComponent implements OnInit {
  productos: any[] = [];
  modalInstance: any;
  isBrowser: boolean;

  constructor(
    private productoService: ProductoService,
    private router: Router,
    @Inject(PLATFORM_ID) private platformId: Object
  ) {
    this.isBrowser = isPlatformBrowser(this.platformId);
  }

  ngOnInit(): void {
    this.obtenerProductos();
    this.productoService.getActualizacionesProductos().subscribe(() => {
      this.obtenerProductos();
    });
  }

  obtenerProductos(): void {
    this.productoService.getProductos().subscribe(productos => {
      console.log("Productos recibidos del backend:", productos);  
      this.productos = productos;
    }, error => {
      console.error("Error al obtener productos", error);
    });
  }

  eliminarProducto(id: number): void {
    if (confirm("¿Seguro quieres eliminar este producto?")) {
      this.productoService.eliminarProducto(id).subscribe(() => {
        this.obtenerProductos();
      });
    }
  }

  abrirModal(): void {
    if (this.isBrowser) {
      const modalElement = document.getElementById("modalProduct");
      if (modalElement) {
        import('bootstrap').then(({ Modal }) => {
          this.modalInstance = new Modal(modalElement);
          this.modalInstance.show();
        });
      }
    }
  }


  private loadBootstrap() {
    if (typeof window !== 'undefined') {
      import('bootstrap').then(() => {
        console.log('Bootstrap cargado');
      }).catch((error) => {
        console.error('Error cargando Bootstrap:', error);
      });
    }
  }
}
