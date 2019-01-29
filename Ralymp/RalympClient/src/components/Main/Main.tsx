import React, {Component} from 'react';
import './main.scss';
import {Switch, Route} from 'react-router-dom'
import Rating from "../Rating/Rating";
import Home from "../Home/Home";

type Props = {activeItem: string};
type State = {};
export default class Main extends Component<Props, State> {

    render() {
        return (
            <main className="Main">
                <Switch>
                    <Route exact path='/home' component={Home}/>
                    <Route exact path='/school' component={() => <Rating page='school'/>}/>
                    <Route exact path='/teacher' component={() => <Rating page='teacher'/>}/>
                    <Route exact path='/student' component={() => <Rating page='student'/>}/>
                    <Route exact path='/subject' component={() => <Rating page='subject'/>}/>
                    <Route path="*" exact component={Home}/>
                </Switch>
            </main>
        );
    }
}

