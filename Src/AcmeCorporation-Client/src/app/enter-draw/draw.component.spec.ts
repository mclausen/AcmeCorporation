import { TestBed, async } from '@angular/core/testing';
import { DrawComponent } from './draw.component';

describe('DrawComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        DrawComponent
      ],
    }).compileComponents();
  }));
  it('should create the and instance', async(() => {
    const fixture = TestBed.createComponent(DrawComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  }));
});
