import { ErrorHandler, Injectable } from '@angular/core';

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {
  // constructor(private logger: NGXLogger) {}

  handleError(error: string): void {
    // this.logger.error(error);
    console.log(error);
  }
}
