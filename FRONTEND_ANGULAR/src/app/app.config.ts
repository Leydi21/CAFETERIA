import { ApplicationConfig } from '@angular/core';
import { provideRouter, withComponentInputBinding } from '@angular/router';
import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideHttpClient, withFetch } from '@angular/common/http';
import { LOCALE_ID } from '@angular/core';
import localeEs from '@angular/common/locales/es';
import { registerLocaleData } from '@angular/common';

registerLocaleData(localeEs);

export const appConfig: ApplicationConfig = {
  providers: [
    provideClientHydration(), 
    provideAnimationsAsync(),
    provideHttpClient(
      withFetch(),
    ),
    provideRouter(
      routes,
      withComponentInputBinding()
    ), 
    { provide: LOCALE_ID, useValue: 'es' },
  ]
};
