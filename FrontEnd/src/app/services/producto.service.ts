import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Product } from './producto.model'; 

@Injectable({
  providedIn: 'root',
})
export class ProductoService {
  private apiProducto = "http://localhost:5184/api/Products";
  private productosActualizados = new Subject<void>();

  constructor(private http: HttpClient) {}

  getProductos(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiProducto);
  }
  

  getProducto(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.apiProducto}/${id}`);
  }

  crearProducto(producto: Product): Observable<Product> {
    return this.http.post<Product>(this.apiProducto, producto).pipe(
      tap(() => {
        this.productosActualizados.next();  
      })
    );
  }

  getActualizacionesProductos(): Observable<void> {
    return this.productosActualizados.asObservable();
  }

  eliminarProducto(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiProducto}/${id}`);
  }
}
