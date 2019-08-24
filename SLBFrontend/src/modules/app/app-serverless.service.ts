import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AppServerlessService {

  private BlobEndpoint = "BlobAzureFunction"

  constructor(private httpClient: HttpClient) { }

  public getValue(): Observable<any> {
    return this.httpClient.get(environment.apiHost + this.BlobEndpoint + "?name=Kamil");
  }
}

