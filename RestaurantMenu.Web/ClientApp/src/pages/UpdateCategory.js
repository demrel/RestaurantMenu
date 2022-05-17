import {
    Text,
    Flex,
    Button,
    Input,
    FormControl,
    FormLabel,
    FormHelperText,
    Box
} from '@chakra-ui/react'


import { useState, useEffect } from 'react'
import axios from 'axios'
import { CategoryItem } from '../components'
import { toBase64 } from '../Helper'
import { useParams } from 'react-router-dom';

const baseData = [
    {
        name: 'Isti Yemek',
        description: 'Testestetetetetetetteet',
        imageUrl: 'https://picsum.photos/200',
    },
    {
        name: 'Soyuq Yemek',
        description: 'Testestetetetetetetteet',
        imageUrl: 'https://picsum.photos/200',

    }
];


export default function UpdateCategory() {
    const [allData, setAllData] = useState(null)
    const [filtervalue, setFilterValue] = useState(null)

    const { id } = useParams();

    const setInputfilterData = (e) => {
        setFilterValue(
            {
                ...filtervalue,
                [e?.target.name]: e?.target?.value
            }
        )
    }

    const setInputfilterImageData = async (e) => {
        const base64Image = await toBase64(e?.target?.files[0]);
        setFilterValue(
            {
                ...filtervalue,
                [e?.target.name]: base64Image
            }
        )
    }





    useEffect(() => {
        console.log('FilterValuyular', filtervalue)
    }, [filtervalue])


    useEffect(() => {
        setAllData(baseData)
        getApidata()
    }, [])

    const getApidata = async () => {
        const response = await axios.get('https://jsonplaceholder.typicode.com/users');
        // setAllData(response)
    }

    const getFilterData = async () => {
        const getData = await axios.post('https://jsonplaceholder.typicode.com/users', {
            filtervalue
        })
            .then(function (response) {
                console.log(response);
                // setAllData(response)
            })
            .catch(function (error) {
                console.log(error);
            });

        console.log('Duyme isledi', filtervalue)
    }

    return (
        <Flex height='100vh' width='100vw' justifyContent={'center'} backgroundColor='#CCCCCC'>
            <Flex width={'1000px'} alignItems='center' flexDirection={'column'}>
                <Text fontSize={'40px'}>Categories</Text>
                <Box width={'100%'} margin="40px">
                    <FormControl>
                        <FormLabel htmlFor='name'>Name</FormLabel>
                        <Input id='name' type='text' />
                        <FormHelperText>Plesae Enter Name</FormHelperText>
                    </FormControl>

                    <FormControl>
                        <FormLabel htmlFor='description'>description</FormLabel>
                        <Input id='description' type='text' />
                        <FormHelperText>Plesae Enter description</FormHelperText>
                    </FormControl>

                    <FormControl>
                        <FormLabel htmlFor='image'>image</FormLabel>
                        <Input id='image' type='file' />
                        <FormHelperText>Upload image</FormHelperText>
                    </FormControl>
                    <Button mt={4} colorScheme='teal'  >
                        Submit
                    </Button>
                </Box>
            </Flex>
        </Flex>
    );
}