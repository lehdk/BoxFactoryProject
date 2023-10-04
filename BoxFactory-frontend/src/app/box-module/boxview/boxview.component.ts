import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Box } from 'src/app/models/Box';
import { BoxService } from 'src/app/services/box.service';

@Component({
    selector: 'app-boxview',
    templateUrl: './boxview.component.html',
    styleUrls: ['./boxview.component.scss'],
})
export class BoxviewComponent implements OnInit, OnDestroy {

    id: number;

    box: Box | null | undefined = undefined;

    subscriptions: Subscription[] = [];

    constructor(private route: ActivatedRoute, private router: Router, private boxService: BoxService) {
        let id = route.snapshot.paramMap.get('id');
        this.id = Number(id);

        if(id == null || isNaN(this.id)) {
            this.goBack();
        }
    }
    
    async ngOnInit() {
        let $boxRequest = this.boxService.getBox(this.id).subscribe(data => {
            this.box = Object.assign(new Box(), data);
        });
        this.subscriptions.push($boxRequest);
    }

    ngOnDestroy(): void {
        for(const s of this.subscriptions){
            s.unsubscribe();
        }
    }
        
    goBack() {
        this.router.navigate(["boxes"]);
        console.log(typeof this.box);
    }
}
