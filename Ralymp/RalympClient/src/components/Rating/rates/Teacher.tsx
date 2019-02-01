import React, {Component, Fragment} from 'react'
import {ITeacher} from "../../../models/Teacher";
import {Table} from 'semantic-ui-react';

type Props = { teachers: ITeacher[] };
type State = {};
export default class Teacher extends Component<Props, State> {
    render() {
        const {teachers} = this.props;
        return (
            <Fragment>
                <Table.Header>
                    <Table.Row>
                        <Table.HeaderCell>Teacher name</Table.HeaderCell>
                        <Table.HeaderCell>School title</Table.HeaderCell>
                        <Table.HeaderCell>Participation</Table.HeaderCell>
                    </Table.Row>
                </Table.Header>
                <Table.Body>
                    {teachers.map((teacher: ITeacher) =>
                        <Table.Row key={teacher.teacherName}>
                            <Table.Cell>
                                <div className='Rating-TableData'>{teacher.teacherName}</div>
                            </Table.Cell>
                            <Table.Cell>
                                <div className='Rating-TableData'>{teacher.schoolTitle}</div>
                            </Table.Cell>
                            <Table.Cell>
                                <div className='Rating-TableData'>
                                    {teacher.participations.map(item =>
                                        <p key={item.subjectName}>
                                            <span>{item.studentName}</span>
                                            <span>{item.subjectName}</span>
                                            <span>{item.place}</span>
                                            <span>{item.year}</span>
                                        </p>
                                    )}
                                </div>
                            </Table.Cell>
                        </Table.Row>
                    )}
                </Table.Body>

            </Fragment>
        )
    }
}

