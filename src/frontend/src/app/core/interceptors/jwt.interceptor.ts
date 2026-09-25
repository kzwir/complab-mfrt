import {
  HttpInterceptorFn
} from '@angular/common/http';

export const jwtInterceptor:
  HttpInterceptorFn =
  (req, next) => {

    const token =
      localStorage.getItem('jwt');

    if (!token) {
      return next(req);
    }

    const clone = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    });

    return next(clone);
  };
