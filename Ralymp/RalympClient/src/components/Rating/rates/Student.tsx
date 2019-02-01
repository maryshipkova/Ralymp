import React, {Component, Fragment} from 'react'
import {IStudent} from "../../../models/Student";
import {Table} from 'semantic-ui-react';

type Props = { students: IStudent[] };
type State = {};
export default class Student extends Component<Props, State> {
    render() {
        const {students} = this.props;
        return (
            <Fragment>
                <Table.Header>
                    <Table.Row>
                        <Table.HeaderCell>Student name</Table.HeaderCell>
                        <Table.HeaderCell>School title</Table.HeaderCell>
                        <Table.HeaderCell>Participation</Table.HeaderCell>
                    </Table.Row>
                </Table.Header>
                <Table.Body>
                    {students.map((student: IStudent) =>
                        <Table.Row key={student.studentName}>
                            <Table.Cell><div className='Rating-TableData'>{student.studentName}</div></Table.Cell>
                            <Table.Cell><div className='Rating-TableData'>{student.schoolTitle}</div></Table.Cell>
                            <Table.Cell>
                                <div className='Rating-TableData'>
                                {student.participation.map(item =>
                                    <p key={item.subjectName}>
                                        <span>{item.subjectName}</span>
                                        <span>{item.place}</span>
                                        <span>{item.year}</span>
                                    </p>
                                )}
                                </div>
                            </Table.Cell>
                        </Table.Row>
                    )
                    }
                </Table.Body>

            </Fragment>
        );
    }
}

