import React, {Component, Fragment} from 'react';
import './profile.scss';
import {Card, Loader} from 'semantic-ui-react';
import {get} from "../../services/fetchService";
import {IStudent} from "../../models/Student";
import {Radar} from 'react-chartjs-2';

type Props = {};
type State = { student: IStudent | null };
export default class Profile extends Component<Props, State> {

    componentWillMount() {
        this.state = {student: null};
        get(`StudentProfile/GetRandomProfile`)
            .then((resp: IStudent) => {
                this.setState({student: resp});

            });
    }

    render() {

        const {student} = this.state;
        // student?console.log(student.categoryRows):null;
        const loader = <Loader active inline='centered'/>;
        // const options = {
        //     borderColor: 'red'
        // };
        return (<Fragment>
            {!student ? loader :
                <Card className='Profile'>
                    <Card.Content className='Profile-Content'>
                        <div className="Profile-Info">
                            <Card.Header className="Profile-Header"><h4>{student.studentName}</h4></Card.Header>
                            <Card.Description>
                                {student.schoolTitle}
                            </Card.Description>
                            <br/>
                            <Card.Description>
                                Wins:
                                <Card.Description>
                                    Municipal:&nbsp;
                                    {student.totalWinsOnMunicipalStage || 0}
                                </Card.Description>
                                <Card.Description>
                                    Regional:&nbsp;
                                    {student.totalWinsOnRegionStage || 0}
                                </Card.Description>
                                <Card.Description>
                                    Country:&nbsp;
                                    {student.totalWinsOnCountryStage || 0}
                                </Card.Description>
                            </Card.Description>
                        </div>
                        <div className="Profile-Chart">
                            {student.categoryRows &&
                            <Radar data={{
                                labels: student.categoryRows.map(row => row.title),
                                datasets: [{
                                    data: student.categoryRows.map(row => row.value)
                                }]
                            }}
                                   legend={false}
                                   options={
                                       {
                                           borderColor: '#36a2eb'
                                       }
                                   }
                            />}
                        </div>
                    </Card.Content>

                </Card>
            }
        </Fragment>);


    }
}
