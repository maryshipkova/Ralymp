import React, {Component} from 'react';
import './rating.scss';
import {Loader} from 'semantic-ui-react'
import Student from "./rates/Student";
import Teacher from "./rates/Teacher";
import {ITeacher} from "../../models/Teacher";
import {IStudent} from "../../models/Student";

type Props = { page: string };
type State = { results: ITeacher | IStudent | null };
export default class Rating extends Component<Props, State> {
    baseUrl = 'https://ralymp.azurewebsites.net/api';
    params: Object = {
        method: 'GET',
        mode: 'cors',
        headers: {
            'Access-Control-Allow-Origin': '*'
        }
    };
    state = {results: null};

    formatRate(page: string) {
        return page.charAt(0).toUpperCase() + page.slice(1) + 'Rate';
    }

    componentWillMount() {
        fetch(`${this.baseUrl}/${this.formatRate(this.props.page)}/GetRandomResultList`, this.params)
            .then((resp) => resp.json())
            .then((resp) => {
                this.setState({results: resp})
            })
            .catch(e => console.log(e));
    }

    render() {
        const {page} = this.props;
        const {results} = this.state;
        const loader = <Loader active inline='centered'/>;
        return (

            <section className="Rating">
                <div className="Rating-Header">
                    <h2 className='Rating-Heading'>{`${page} rate`.toUpperCase()}
                    </h2>
                </div>
                <div className="Rating-Results">
                    {!results ? loader:
                        (page === 'student' && <Student students = {results}/> ||
                        page === 'teacher' && <Teacher teachers = {results}/>)
                    }
                </div>
            </section>
        );
    }
}

