import {
    Text,
    Flex,
    Button,
    Input,
    Box
} from '@chakra-ui/react'


import { useState, useEffect } from 'react'
import axios from 'axios'
import { CategoryItem } from '../components'
import { toBase64 } from '../Helper'

const baseData = [
    {
        Id: 1,
        name: 'category name',
        description: 'categ desc',
        imageUrl: 'https://picsum.photos/200',
    },
    {
        Id: 2,
        name: 'category name 2',
        description: 'categ desc 2',
        imageUrl: 'https://picsum.photos/200',

    }
];


export default function Category() {
    const [allData, setAllData] = useState([])
    const [postValue, setPostValue] = useState(null)


    const setInputPostData = (e) => {
        setPostValue(
            {
                ...postValue,
                [e?.target.name]: e?.target?.value
            }
        )
    }

    const setInputfilterImageData = async (e) => {
        const base64Image = await toBase64(e?.target?.files[0]);
        setPostValue(
            {
                ...postValue,
                [e?.target.name]: base64Image
            }
        )
    }





    useEffect(() => {
        console.log('FilterVaue', postValue)
    }, [postValue])


    useEffect(() => {
        getApidata()
        console.log(allData);
    }, [])

    const getApidata = async () => {
        const response = await axios.get('https://localhost:7266/api/category');
        console.log("response", response);
        setAllData(response.data)
    }

    const getFilterData = async () => {
        console.log(postValue);
        await axios.post('https://localhost:7266/api/category', {
            postValue
        })
            .then(function (response) {
                getApidata()

            })
            .catch(function (error) {
                console.log("Eroor gettt",error);
                // setAllData(response)
            });

        console.log('Duyme isledi', postValue)
    }

    return (
        <>
            <Flex justify={'center'} width='100%' marginTop={"40px"}>
                <Flex flexDirection={'row'} height='100px' width='50%' align={'center'} justifyContent='space-around' >
                    <Input name='name' size='lg' marginLeft={'10px'} placeholder='Name' onChange={(e) => setInputPostData(e)} />
                    <Input name='description' size='lg' marginLeft={'10px'} placeholder='Description' onChange={(e) => setInputPostData(e)} />
                    <Input type="file" name='ImageBase64' size='lg' marginLeft={'10px'} placeholder='Basic usage' aria-hidden="true" accept="image/*" onChange={(e) => setInputfilterImageData(e)} />
                    <Button colorScheme='teal' size='lg' marginLeft={'10px'} onClick={getFilterData} >Add</Button>
                </Flex>
            </Flex>
            <Flex height='100vh' width='100vw' justifyContent={'center'} backgroundColor='#CCCCCC'>
                <Flex width={'1000px'} alignItems='center' flexDirection={'column'}>
                    <Text fontSize={'40px'}>Categories</Text>

                    <Box width={'100%'} margin="40px">
                        {allData?.map((item, index) => {

                            return (<CategoryItem item={item} key={index} />)
                        })}
                    </Box>


                </Flex>
            </Flex>
        </>
    );
}