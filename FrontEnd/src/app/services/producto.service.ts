import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})

export class ProductoService {
  private apiProducto = "http://localhost:5184/api/Products";

  constructor(private http: HttpClient) {}

  getProductos(): Observable<any[]>{
    return this.http.get<any[]>(this.apiProducto);
  }

  getProducto(id: number): Observable<any>{
    return this.http.get<any[]>(`${this.apiProducto}/${id}`);
  }

  crearProducto(producto: any): Observable<any>{
    return this.http.post<any>(this.apiProducto, producto);
  }

  actualizarProducto(id: number, producto: any): Observable<any>{
    return this.http.put<any>(`${this.apiProducto}/${id}`, producto);
  }

  eliminarProducto(id: number): Observable<any>{
    return this.http.delete<any>(`${this.apiProducto}/${id}`);
  }
}
