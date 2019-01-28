import React, {Component} from 'react';
import {Switch, Route} from 'react-router-dom'
import Rating from "../Rating/Rating";
import Home from "../Home/Home";

export default class Main extends Component {
    render() {
        return (
            <main className="Main">
                <Switch>
                    <Route exact path='/home' component={Home}/>
                    <Route exact path='/school' component={Rating}/>
                    <Route exact path='/teacher' component={Rating}/>
                    <Route exact path='/student' component={Rating}/>
                    <Route exact path='/subject' component={Rating}/>
                    <Route path="*" exact component={Home} />
                </Switch>
            </main>
        );
    }
}

