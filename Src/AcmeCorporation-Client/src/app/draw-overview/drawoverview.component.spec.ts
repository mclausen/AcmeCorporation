import { TestBed, async } from '@angular/core/testing';
import { DrawOverviewComponent } from './drawoverview.component';

describe('DrawOverviewComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        DrawOverviewComponent
      ],
    }).compileComponents();
  }));
  it('should create the and instance', async(() => {
    const fixture = TestBed.createComponent(DrawOverviewComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  }));
});
