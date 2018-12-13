import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from "@angular/common/http";
import { Observable } from "rxjs";
import { Injectable } from '@angular/core';
import { AuthService } from "../services/auth.service";

@Injectable()

export class AuthInterceptor implements HttpInterceptor {

    constructor(private authService: AuthService) { }

    intercept(req: HttpRequest<any>,
        next: HttpHandler): Observable<HttpEvent<any>> {
            const idToken = localStorage.getItem('tokenInfo');

        if (idToken) {
            const cloned = req.clone({
                headers: req.headers.set("Authorization",
                    `Bearer ${idToken}`)
            });
            return next.handle(cloned);
        }
        else {
            return next.handle(req);
        }
    }
}